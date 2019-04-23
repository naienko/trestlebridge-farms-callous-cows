using Trestlebridge.Models.Processors;

namespace Trestlebridge.Interfaces
{
    public interface IMeatProducing
    {
        double Process (MeatProcessor equipment);
    }
}