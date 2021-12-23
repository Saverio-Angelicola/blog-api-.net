[![Contributors][contributors-shield]][contributors-url] [![Forks][forks-shield]][forks-url] [![Stargazers][stars-shield]][stars-url] [![Issues][issues-shield]][issues-url]

## About The Project

![Product Name Screen Shot][product-screenshot]

It is a back-end Web API type application developed in C # and .Net Core 6 to manage a blog with authentication.
I created this personal project in my free time in order to learn and progress in C #, .Net and the Microsoft eco-system.

### Built With

* C#
* .Net Core 6
* Entity Framework 6
* ProstgreSQL
* Nunit (Unit Test)
* Docker
* Github
* Visual studio 2022

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites
* .Net 6
* Docker and Docker Compose
* Visual studio 2022

### Installation
 
1. Clone the repo
```sh
git clone https://github.com/Saverio-Angelicola/blog-api-.net
```
3. Open visual studio 2022 or other IDE
4. Open project and execute the following command
```sh
docker compose up -d
dotnet ef database update
dotnet run
```


<!-- USAGE EXAMPLES -->
## Usage

Once you run the project to test the api you will be able to access the open api documentation with swagger at the local address: https://localhost:7057/swagger


<!-- CONTACT -->
## Contact

Angelicola Saverio - Linkedin : [Saverio Angelicola](https://www.linkedin.com/in/saverio-angelicola-2669871b3) - Email : pro@angelicola-saverio.fr

Project Link: [https://github.com/Saverio-Angelicola/blog-api-.net](https://github.com/Saverio-Angelicola/blog-api-.net)





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/NicolasBrondin/basic-readme-template.svg?style=flat-square
[contributors-url]: https://github.com/Saverio-Angelicola/blog-api-.net/contributors
[forks-shield]: https://img.shields.io/github/forks/NicolasBrondin/basic-readme-template.svg?style=flat-square
[forks-url]: https://github.com/Saverio-Angelicola/blog-api-.net/network/members
[stars-shield]: https://img.shields.io/github/stars/NicolasBrondin/basic-readme-template.svg?style=flat-square
[stars-url]: https://github.com/Saverio-Angelicola/blog-api-.netstargazers
[issues-shield]: https://img.shields.io/github/issues/NicolasBrondin/basic-readme-template.svg?style=flat-square
[issues-url]: https://github.com/Saverio-Angelicola/blog-api-.net/issues
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/othneildrew
[product-screenshot]: docs/cover.jpg
