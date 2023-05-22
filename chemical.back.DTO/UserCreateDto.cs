namespace chemical.back.DTO
{
    public sealed class UserCreateDto
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserState { get; set; }
    }
}
