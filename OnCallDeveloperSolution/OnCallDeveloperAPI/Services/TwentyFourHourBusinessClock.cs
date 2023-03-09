using OnCallDeveloperAPI.Controllers;

namespace OnCallDeveloperAPI.Services;

public class TwentyFourHourBusinessClock : IProvideTheBusinessClock
{
    public bool IsDuringBusinessHours()
    {
        return true;
    }
}
