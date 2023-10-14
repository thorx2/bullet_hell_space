using Godot;
using System;

public partial class ScrollingGameMap : ParallaxBackground
{
	[Export] private float _ScrollSpeed;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var sOff = ScrollOffset;
		sOff.Y += _ScrollSpeed * (float)delta;
		ScrollOffset = sOff;
	}
}
