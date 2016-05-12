namespace GM.Business.Entity
{
    public class ProductTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
    }
}
