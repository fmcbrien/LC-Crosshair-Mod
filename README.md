<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

As my first offical personal coding "project", this program was created as a way to teach myself C# for Unity using BepInEx to create a mod for the game Lethal Company. I do not claim this project to be an original work as it was entirely based off of the current Onionmilk_Crosshair mod and used as a way for me to break down the existing code and recreate it in my own program and understand the complexities of creating games/mods in Unity. **Note: I do not take full credit for this mod. This was a learning experience for me, not an original creation.**

Future Planned Improvements:
* Customizable mod similar to FPS games where you can change the size, shape, and color of the crosshair in the settings menu
* Ability to change the crosshair in game settings menu

Next Steps:
* Create a more complex, original mod with the knowledge I learned  

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![C#][C-Sharp-Icon]][C-Sharp-url]
* [![Unity][Unity-Icon]][Unity-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

Setting up this mod on your computer.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* [BepInEx][bepinex-github]
  * make sure to have BepInEx installed in your steam folder for Lethal Company
  * instructions on how to install on BepInEx [website][bepinex-instructions]

### Installation

_Installing mod as plugin in BepInEx_

1. If "plugins" folder is not present in your BepInEx folder (/steamapps/common/LethalCompany/BepInEx), run the game once, then close it. If it is still not present, add a folder labeled "plugins"
2. In this folder, add the crosshair dll file and any .png files of crosshairs you would like.
3. Run the game and choose your crosshair in the menu screen.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- ROADMAP -->
## Roadmap

- [x] Learn basic level of C#
- [x] Break down Onionmilk_Crosshair mod
- [x] Recreate Onionmilk_Crosshair mod
- [ ] Add in-game settings menu crosshair updates
- [ ] Create more customizability for crosshair
    - [ ] adjust shape/size in game based on center dot, inner, and outer lines
    - [ ] adjust color in game

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Fallon - [LinkedIn](https://www.linkedin.com/in/fallon-mcbrien/) - fmcbrien@bu.edu

Project Link: [https://github.com/fmcbrien/LC-Crosshair-Mod](https://github.com/fmcbrien/LC-Crosshair-Mod)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

Use this space to list resources you find helpful and would like to give credit to. I've included a few of my favorites to kick things off!

* [Onionmilk_Crosshair](https://thunderstore.io/c/lethal-company/p/OnionMilk/crosshair/)
* [MrMiinxx-How To Write Your Own Mod From Scratch](https://www.youtube.com/watch?v=4Q7Zp5K2ywI)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
[C-Sharp-Icon]: https://img.shields.io/badge/-C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white
[C-Sharp-URL]: https://learn.microsoft.com/en-us/dotnet/csharp/
[Unity-Icon]: https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=unity&logoColor=white
[Unity-url]: https://unity.com/
[bepinex-github]: https://github.com/BepInEx/BepInEx
[bepinex-instructions]: https://docs.bepinex.dev/articles/user_guide/installation/index.html
