using Trestlebridge.Models.Processors;

namespace Trestlebridge.Interfaces
{
    public interface ISeedProducing : IResource
    {
        double Process (SeedProcessor equipment);
    }
}