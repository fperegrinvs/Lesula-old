Lesula - Cassandra MapReduce framework in c#
======

Requirements:
- Cassandra >= 1.1

Known restrictions (aka what was left behind to get things done with current manpower):
- Column names must be UTF8 Strings
- Super columns not supported
- Everything works in the same cassandra cluster
- Only the custom built-in cassandra client supported. (should no be a issue for end-users)