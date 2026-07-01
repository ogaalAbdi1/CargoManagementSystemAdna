using System.Data;

namespace CargoManagementSytem.Model
{
    public class Shipments
    {
        public int ShipmentId {  get; set; }
        public int Cargoid {  get; set; }
        public int StatusId {  get; set; }
        public  DateTime ShipmentData {  get; set; }
        public string Destination {  get; set; }
        public DateTime ExpectedDelivery {  get; set; }
    }
}
