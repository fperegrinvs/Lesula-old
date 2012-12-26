Lesula - Cassandra MapReduce framework in c#
======

Requirements:
- Cassandra >= 1.1
- Some test projects requires Specflow (>= 1.9.1 - http://visualstudiogallery.msdn.microsoft.com/9915524d-7fb0-43c3-bb3c-a8a14fbd40ee) to run.

Known restrictions (aka what was left behind to get things done with current manpower):
- Column names must be UTF8 Strings
- Super columns not supported
- Only the custom built-in cassandra client supported. (should no be a issue for end-users)

Credits
Lesula Cassandra code is derived from Aquiles (http://aquiles.codeplex.com/)