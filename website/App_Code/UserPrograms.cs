using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class UserPrograms
{
    public String username;
    public List<Program> programs;
    

    public List<Program> getPrograms()
    {
        return programs;
    }

    public void addProgram(Program program)
    {
        programs.Add(program);
    }

    
}


