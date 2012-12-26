Feature: MachineBootstrap
	In order to avoid single point of failures, cluster unbalances and sily mistakes
	As a system admin
	I want my cluster machines to autoconfigure themselves.

Scenario Outline: New machines
	Given the cluster have <old> machines
	When <new> machines bootstraps
	Then cluster must contain <total> machines
Examples: 
	| old | new | total |
	| 0   | 1   | 1     |
	| 1   | 1   | 2     |
	| 1   | 2   | 3     |
	| 2   | 2   | 4     |
	| 3   | 2   | 5     |
	| 5   | 3   | 8     |

Scenario Outline: New peer
	Given the cluster have <old> machines and each machine is configured to have <maxPeer> peers
	When 1 machine bootstraps
	Then the new machine must be listed as peer of <peer> machines
Examples: 
	| old | maxPeer | peer |
	| 1   | 3       | 1    |
	| 2   | 3       | 2    |
	| 3   | 3       | 3    |
	| 4   | 3       | 3    |
	| 4   | 2       | 2    |

Scenario Outline: Concurrent Bootstrap
	Given the cluster have <old> machines
	When <new> machines bootstrap
	And cluster summary info is wrong
	Then some machine must fix the summary
Examples: 
	| old | new |
	| 1   | 2   |
	| 2   | 2   |
	| 3   | 3   |
	| 2   | 5   |
