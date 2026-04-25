using Godot;
using System;

public static class Utils
{
    public static string GetRandomMeteorPath()
    {
        string[] colors = { "Brown", "Grey" };
        string color = colors[GD.Randi() % (uint)colors.Length];

        string[] sizes = { "med", "big", "big", "big" };
        string size = sizes[GD.Randi() % (uint)sizes.Length];

        int maxNumber;

        if (size == "big")
        {
            maxNumber = (int)GD.RandRange(1, 4);
        }
        else
        {
            maxNumber = (int)GD.RandRange(1, 2);
        }

        return $"res://kenney_space-shooter-remastered/PNG/Meteors/meteor{color}_{size}{maxNumber}.png";
    }
}