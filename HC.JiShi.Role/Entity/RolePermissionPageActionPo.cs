namespace HC.JiShi.UserRole.Entity
{
    public class RolePermissionPageActionPo
    {
        public int RoleId { get; set; }

        public int PageActionId { get; set; }

        public int PageId { get; set; }

        public string ActionName { get; set; }

        public string ActionUrl { get; set; }
    }
}