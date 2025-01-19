﻿namespace Workplanner.Domain;

public class PlanningShift
{
    public Guid Id { get; set; }
    public PlanningPeriod PlanningPeriod { get; set; }
    public Shift Shift { get; set; }
    public User User { get; set; }
}