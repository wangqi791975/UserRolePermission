namespace HC.JiShi.UserRole.Entity
{
    public class UserPermissionPageActionPo
    {
        public int UserId { get; set; }

        public int PageActionId { get; set; }

        public int PageId { get; set; }

        public string ActionName { get; set; }

        public string ActionUrl { get; set; }
    }
}