namespace TreeStructure.Models
{
    public class ParentSubType
    {
        public int nodeId { get; set; }
        public string nodeName { get; set; }
        public string parentNodeId { get; set; }
        public bool isActive { get; set; }
        public DateTime startDate { get; set; }
    }
}
