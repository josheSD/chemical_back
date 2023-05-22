namespace chemical.back.DTO
{
    public sealed class UserUpdateDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserState { get; set; }
    }
}
