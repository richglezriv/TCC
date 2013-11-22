using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Test
/// </summary>
public class Test
{
    public static String Title;
    public String Called { get; set; }

    public Test()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void MethodCall(){
        
        this.Called = "In the street";
    }
}
