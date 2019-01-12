# Perlin Noise Grid

A small class to create a grid of random noise at a given scale.

Add [PerlinNoiseGrid.cs](https://github.com/antonpantev/perlin-noise-grid/blob/master/Assets/Scripts/PerlinNoiseGrid.cs) to your Unity project and use like so like so:

```c#
PerlinNoiseGrid noise = new PerlinNoiseGrid(width, height, perlinScale);

for (int i = 0; i < width; i++)
{
    for (int j = 0; j < height; j++)
    {
        Debug.Log(noise[i, j]);
    }
}
```

<img src="https://raw.githubusercontent.com/antonpantev/perlin-noise-grid/master/PreviewImages/ScreenShot.png">
