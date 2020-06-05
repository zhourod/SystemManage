namespace ZhouRod.SystemManage.SystemManage.TM
{
    public enum TaskState : byte
    {
        /// <summary>
        /// The task is active.
        /// </summary>
        Active = 1,

        /// <summary>
        /// The task is completed.
        /// </summary>
        Completed = 2,

        Inactive = 3
    }
}
