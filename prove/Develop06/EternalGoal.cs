using System;
class EternalGoal : Goal
{
    private bool _isComplete;
    public EternalGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override string ShortName => _name;
    
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal Goal:{_name},{_description},{_points}";
    }

    public override string GetDetailsString()
    {
         // Format: [ ] or [X] based on completion status
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    public static EternalGoal FromString(string details)
    {
        var parts = details.Split(',');
        if (parts.Length != 3)
        {
            throw new ArgumentException("Invalid details format for EternalGoal.");
        }

        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);

        return new EternalGoal(name, description, points);
    }
}