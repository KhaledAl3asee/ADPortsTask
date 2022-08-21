namespace ADPortsTask.DTOs
{
    public class UserPasswordRestoreDto : UserNewPasswordDto
    {
        public string RestoreToken { get; set; }
    }
}
