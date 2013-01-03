using System;
using System.Collections.Generic;

public class responseGroups
{
    public List<Response> response { get; set; }
    public responseGroups()
	{
	}
}

public class RootObject
{
    
}

public class Comments
{
    public int count { get; set; }
}

public class Likes
{
    public int count { get; set; }
}

public class Reposts
{
    public int count { get; set; }
}

public class Response
{
    public int id { get; set; }
    public int from_id { get; set; }
    public int to_id { get; set; }
    public int date { get; set; }
    public string text { get; set; }
    public Comments comments { get; set; }
    public Likes likes { get; set; }
    public Reposts reposts { get; set; }
}