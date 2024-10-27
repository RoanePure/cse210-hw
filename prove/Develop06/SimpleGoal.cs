using System;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
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
        return $"Simple Goal:{_name},{_description},{_points},{_isComplete}";
    }

    public override string GetDetailsString()
    {
        // Format: [ ] or [X] based on completion status
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    public static SimpleGoal FromString(string details)
    {
        var parts = details.Split(',');
        if (parts.Length != 4)
        {
            throw new ArgumentException("Invalid details format for SimpleGoal.");
        }

        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);
        bool isComplete = bool.Parse(parts[3]);

        return new SimpleGoal(name, description, points, isComplete);
    }
}