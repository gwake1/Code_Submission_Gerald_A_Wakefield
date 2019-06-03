using Code_Submission_Gerald_A_Wakefield.Interface;
using Code_Submission_Gerald_A_Wakefield.Services;

namespace Code_Submission_Gerald_A_Wakefield.Configuration
{
    public class BootStrapper
    {
        public static void Init()
        {
            ServiceInjector.Register<IInputService, InputService>();
        }
    }
}
