using Domain.Shared;

namespace Domain.Errors;

public static class AppUserErrors
{
    public static Error InvalidEmailAddress = new Error("InvalidEmailAddress", "Provided email is invalid!");
}
