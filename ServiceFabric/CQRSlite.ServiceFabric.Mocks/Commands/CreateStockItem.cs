using CQRSlite.Commands;

namespace CQRSlite.ServiceFabric.Mocks.Commands
{
    public class CreateStockItem : ICommand
    {
        private CreateStockItem()
        {
        }

        public CreateStockItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
        public int ExpectedVersion { get; set; }
    }
}