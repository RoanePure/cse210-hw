using System;

class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _timesCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int timesCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    public override string ShortName => _name;

    public override int RecordEvent()
    {
        _timesCompleted++;
        
        // Check if the target number of completions has been reached
        if (_timesCompleted == _target)
        {
            // Award points plus bonus, but do not reset the counter
            return _points + _bonus;
        }
        
        // Award regular points for progress towards the goal
        return _points;
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist Goal:{_name},{_description},{_points},{_target},{_bonus},{_timesCompleted}";
    }

    public override string GetDetailsString()
    {
        // Format: [ ] with completion progress
        string status = _timesCompleted >= _target ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Currently completed: {_timesCompleted}/{_target}";
    }

    public static ChecklistGoal FromString(string details)
    {
        var parts = details.Split(',');
        if (parts.Length != 6)
        {
            throw new ArgumentException("Invalid details format for ChecklistGoal.");
        }

        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);
        int target = int.Parse(parts[3]);
        int bonus = int.Parse(parts[4]);
        int timesCompleted = int.Parse(parts[5]);

        return new ChecklistGoal(name, description, points, target, bonus, timesCompleted);
    }
}