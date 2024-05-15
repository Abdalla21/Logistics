namespace LogisticsDataCore.Constants.ControllersConstants
{
    public static class RoleConstants
    {
        public const string AdminRole = "Admin";
        public const string AdminRoleDesc = "Has All The privileges for the current tenant.";

        public const string BranchManagerRole = "Branch Manager";
        public const string BranchManagerRoleDesc = "Has All The privileges for the current Branch.";

        public const string LogisticRoleRole = "Logistic";
        public const string LogisticRoleRoleDesc = "Can see the materials which is lacking in the branches.";
    }
}
