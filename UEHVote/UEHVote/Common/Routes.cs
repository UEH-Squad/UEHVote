namespace VMS.Common
{
    public static class Routes
    {
        #region Main

        public const string HomePage = "/";
        public const string RankPage = "/bang-xep-hang";
        public const string DetailVote = "/chi-tiet-de-cu";
        public const string ListElection = "/danh-sach-cac-cuoc-bau-cu";

        #endregion Main

        #region Admin

        public const string AdminApproveElection = "/admin/duyet-binh-chon";
        public const string AdminDetailElection = "/admin/chi-tiet-binh-chon";
        public const string AdminDetailNomination = "/admin/chi-tiet-de-cu";
        #endregion Admin
    }
}