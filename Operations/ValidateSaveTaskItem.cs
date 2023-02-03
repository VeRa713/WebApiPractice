namespace WebApiTest.Operations;

public class ValidateSaveTaskItem
{
    private Dictionary<string, object> payload;
    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveTaskItem(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();

        Errors.Add("id", new List<string>());
        Errors.Add("task_name", new List<string>());
        Errors.Add("status", new List<string>());
        Errors.Add("priority", new List<string>());
        Errors.Add("desc", new List<string>());
        Errors.Add("team_id", new List<string>());
    }

    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["id"].Count > 0)
        {
            ans = true;
        }

        if (Errors["task_name"].Count > 0)
        {
            ans = true;
        }

        if (Errors["status"].Count > 0)
        {
            ans = true;
        }

        if (Errors["priority"].Count > 0)
        {
            ans = true;
        }

        if (Errors["desc"].Count > 0)
        {
            ans = true;
        }

        if (Errors["team_id"].Count > 0)
        {
            ans = true;
        }

        return ans;
    }

    public bool HasNoErrors()
    {
        return !HasErrors();
    }

    public void Execute()
    {
        //Task Id validation
        //check if less than 0
        //check if non duplicate
        //check data type
        if (!payload.ContainsKey("id"))
        {
            Errors["id"].Add("Task Id is required");
        }

        //Task Name validation
        //check if not an empty string
        if (!payload.ContainsKey("task_name"))
        {
            Errors["task_name"].Add("Task Name is required");
        }

        //Status validation
        //check if not an empty string
        //check data type
        if (!payload.ContainsKey("status"))
        {
            Errors["status"].Add("Status is required");
        }

        //Priority validation
        //check if not an empty string 
        //check if within range (1-3)
        //check data type
        if (!payload.ContainsKey("priority"))
        {
            Errors["priority"].Add("Priority is required");
        }

        //check data type
        //check if existing id (once team model is created)
        if (payload.ContainsKey("team_id"))
        {

        }
        else
        {
            Errors["team_id"].Add("Team Id should be an int");
        }
    }
}
