# Apress Source Code

This repository accompanies [*Developing 2D Games with Unity: Independent Game Programming with C#*](https://www.apress.com/9781484237717) by Jared Halpern (Apress, 2018).

[comment]: #cover
![Cover image](9781484237717.jpg)

Download the files as a zip using the green button, or clone the repository to your machine using Git.

## Releases

Release v1.0 corresponds to the code in the published book, without corrections or updates.

## Contributions

See the file Contributing.md for more information on how you can contribute to this repository.

## Errata

#### Chapter 3, Page 53
Credit: [@omundy](https://github.com/omundy)

After stopping the playing scene, add the animation for the player's idle state. From the Sprites folder, select the last *two* sprites from the Player32x32 sprite-sheet, titled: `Player32x32_12` and `Player32x32_13` and drag them onto the PlayerObject. When prompted by the Create New Animation save window, name the created animation-clip, "player-idle" and save to the Animations -> Animations folder.

#### Chapter 4, Page 93

In the **Creating Tile Palettes** section, the `Tile Palette` window in Unity 2018.3 is now located under `Window -> 2D -> Tile Palette`.

#### Chapter 4, Page 128
Credit: [@omundy](https://github.com/omundy)

Make sure to attach the `RoundCameraPos` script to the virtual camera object. Drag and drop the `RoundCameraPos` onto "CM vcam1".





#### Chapter 5, Page 147 
Credit: [@omundy](https://github.com/omundy) 

Create the GameObject in the hierarchy view (not project view). 

#### Chapter 5, Page 162
Credit: [@omundy](https://github.com/omundy) 

In the **Assembling Our Item** section, third paragraph, rename the Scriptable Object, "Coin" (not "Item"). 

#### Chapter 5, Page 164
Credit: [@omundy](https://github.com/omundy) 

In the **Player Collisions** section, the first line of code section `// 3`, should be:

```
print("Hit: " + hitObject.objectName);
```

#### Chapter 5, Page 166
Credit: [@omundy](https://github.com/omundy) 

Steps 10 and 11 are duplicates of step 3.




#### Chapter 6, Page 198
Credit: [@omundy](https://github.com/omundy) 

Under the heading **Create the HealthBar Script**, right-click in the MonoBehaviours folder **and create a new C# script** called HealthBar."



