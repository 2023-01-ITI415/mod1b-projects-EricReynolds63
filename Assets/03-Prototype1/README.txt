
	Prototype 1 - Ghost Maze
	
	Loosely based on Pacman and Monkey Ball
	
	Gameplay Loop:
		-Player dodges ghosts while collecting 'pips' for points as they rain down from the sky
		-At certain score thresholds, a bridge appears to the next arena
		-Each arena has associated pips worth more points, but harder terrain and more ghosts
	
	Components:
		Game Controller
			-Unique Object
			-Controls game events like player lives/scene resets when lives lost, game overs, etc.
		Arena Controller
			-One per Arena
			-Controls Pip and Ghost spawning
			-Planned 'Shake' button to knock player and pips into the air briefly (like a pinball machine)
		Arena
			-Area for the player to traverse, Pips land here
		Player
			-Player rolls around with WASD (friction slows the ball when controls released)
			-If player falls off Arena, lose a life
			-If player touches a Ghost, lose a life
		Pip
			-Falls from above to be collected by player
			-Expires after a while
			-Deleted if it falls off the arena
		Ghost
			-Spawns just beyond edge of arena, moves in a straight line

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

		v Delete before final build v 

		TO DO -
		-Make Ghosts cause lives to be lost
		-Ghost trails (refer to mission demolition projectiles)
		-UI (Lives, Score)
		-Shake/Bump (Fling player and Pips into air with random X/Z 'drift', has cooldown)
		-More Arenas (Different Controller instances, Special Pips)

		Maybe Implement
		-Game Over/Highscore Leaderboard Screen
