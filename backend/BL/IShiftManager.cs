﻿using Workplanner.Domain;

namespace Workplanner.BL;

public interface IShiftManager
{
    Shift? GetShiftById(Guid id);
    
    Shift AddShift(string name,TimeOnly start, TimeOnly end);
    
    IEnumerable<Shift> GetAllShifts();
}