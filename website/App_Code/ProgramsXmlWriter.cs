using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Serialization;

/// <summary>
/// uses an XML Serializer to write xml files of user programs to the App_Data directory
/// </summary>
public class ProgramsXmlWriter
{
    private UserPrograms programs;
	public ProgramsXmlWriter(UserPrograms programs)
	{
        this.programs = programs;
    }

    public void writeXML()
    {
        XmlSerializer writer = new XmlSerializer(typeof(UserPrograms)); //initialze XmlSerializer object
        String path = HttpContext.Current.Server.MapPath("~/App_Data/" + programs.username + ".xml"); //get path for file

        FileStream file = File.Create(path); //create new xml file

        writer.Serialize(file, programs); //write the xml
        file.Close(); //close the file
        
    }
}