using Microsoft.Exchange.WebServices.Data;
using System.Net;
using TnTetraPusher.Core.Engine;
using TnTetraPusher.Engine.ContentHandlers;
using Task = System.Threading.Tasks.Task;

namespace TnTetraPusher.Engine.EmailReaders
{
    public class ExchangeEmailReader : IEmailReader
    {
        public IContentHandler contentHandler; 

        public ExchangeEmailReader(IContentHandler contentHandler)
        {
            this.contentHandler = contentHandler;
        }

        public async Task RunAsync()
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

            service.Credentials = new NetworkCredential("SVCDN01-AIS_TOR_Test", @"6^dWpPXgCJqk0^5pf1jX");

            service.Url = new Uri("https://dmn-mail.dmn.tn.corp/EWS/Exchange.asmx");

            String MailboxToAccess = "SVCDN01-AIS_TOR_Test@dmn.transneft.ru";

            SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false);


            FolderId FolderToAccess = new FolderId(WellKnownFolderName.Inbox, MailboxToAccess);
            ItemView ivItemView = new ItemView(10);
            FindItemsResults<Item> FindItemResults = service.FindItems(FolderToAccess, sfSearchFilter, ivItemView);
            PropertySet ItemPropertySet = new PropertySet(BasePropertySet.IdOnly)
            {
                ItemSchema.Body,
                ItemSchema.Subject,
                EmailMessageSchema.Body,
                EmailMessageSchema.Subject,
                EmailMessageSchema.Sender
            };
            ItemPropertySet.RequestedBodyType = BodyType.Text;


            var items = service.FindItems(WellKnownFolderName.Inbox, new ItemView(100));

            if (items.Count() == 0)
            {
                return;
            }

            //  https://stackoverflow.com/questions/26028760/how-to-retrieve-mail-message-body-with-exchange-2010-in-c-sharp
            service.LoadPropertiesForItems(items.Items, ItemPropertySet);

            foreach (var item in items.Items)
            {

                await this.contentHandler.RunAsync((item as EmailMessage)?.Subject, (item as EmailMessage)?.Body, (item as EmailMessage)?.Sender.Address);

                service.DeleteItems(items.Items.Where(x => x.Id == item.Id).Select(x => x.Id), DeleteMode.HardDelete, null, null);
            }

            //service.DeleteItems(items.Items.Select(x => x.Id), DeleteMode.HardDelete, null, null);
        }
    }
}
