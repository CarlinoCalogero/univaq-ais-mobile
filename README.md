<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a id="readme-top"></a>

<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT HEADER -->
<br />
<div align="center">
  <h3 align="center">AIS Mobile</h3>

  <p align="center">
    An Augmented Reality (AR) mobile application built with Unity and AR Foundation for 2D image tracking and dynamic runtime 3D GLTF model streaming.
    <br />
    <a href="https://github.com/CarlinoCalogero/univaq-ais-mobile"><strong>Explore the repository »</strong></a>
    <br />
    <br />
    <a href="https://github.com/CarlinoCalogero/univaq-ais-mobile/issues">Report Bug</a>
    &middot;
    <a href="https://github.com/CarlinoCalogero/univaq-ais-mobile/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#key-features">Key Features</a></li>
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
    <li><a href="#usage">Usage</a></li>
    <li><a href="#contributors">Contributors</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

**AIS Mobile** is a mobile Augmented Reality (AR) application developed as an academic university project at the **University of L'Aquila (UNIVAQ)** within the Master's Degree in Computer Science (Advanced Software Engineering).

The application leverages AR image tracking to detect physical target images in the real world through the device camera. Upon recognizing a target image, the client communicates with a RESTful backend server, retrieves the corresponding 3D asset metadata and presigned URL, and dynamically streams, loads, and instantiates 3D glTF/GLB models at runtime directly anchored in AR space.

### Key Features

* **Real-time 2D Image Tracking**: Powered by AR Foundation and Google ARCore (`ARTrackedImageManager`) tracking predefined image markers.
* **Dynamic 3D Asset Streaming**: Asynchronously fetches model metadata and presigned download URLs from a REST backend API (`/api/models/{modelKey}`) instead of bundling heavy assets in the build.
* **Frame-Budgeted Runtime Instantiation**: Utilizes `glTFast` with `TimeBudgetPerFrameDeferAgent` to stream and instantiate GLTF/GLB assets smoothly without UI stuttering.
* **Interactive Spawning & Visual Feedback**: Displays an animated 3D loading spinner during download and anchors models with custom position and rotation interaction constraints.
* **Configurable Network Client**: In-app UI allowing users to configure and persist the target backend server IP address via `PlayerPrefs`.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

* [![Unity][Unity]][Unity-url]
* [![C#][CSharp]][CSharp-url]
* [![AR Foundation][ARFoundation]][ARFoundation-url]
* [![Google ARCore][ARCore]][ARCore-url]
* [![glTFast][glTFast]][glTFast-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

Follow the instructions below to get a local copy set up and running on your development environment or ARCore-compatible Android device.

### Prerequisites

* **Unity Editor**: Version `2023.2.22f1`
  * Android Build Support module (Android SDK & NDK tools, OpenJDK)
* **Target Hardware**:
  * An **ARCore-supported Android device** (running Android 7.0 or later), OR
  * Unity Editor with XR Simulation environments enabled for local testing
* **Backend Server**:
  * An accessible backend server hosting the AIS Model REST API (serving `GET /api/models/{modelKey}`)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/CarlinoCalogero/univaq-ais-mobile.git
   ```
2. Open **Unity Hub** and click **Add** > **Add project from disk**, then select the cloned repository folder.
3. Ensure Unity version **2023.2.22f1** is selected and open the project.
4. Allow Unity to resolve and import package dependencies specified in `Packages/manifest.json`.
5. Open the main scene:
   ```
   Assets/Scenes/MainScene.unity
   ```
6. Switch the build target to Android:
   * Go to **File** > **Build Settings...**
   * Select **Android** under Platform and click **Switch Platform**.
7. Connect your ARCore-enabled device via USB (with USB Debugging enabled) and click **Build and Run**.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

1. **Connect to Backend**:
   * Launch the application on your Android device.
   * On the initial screen, enter your backend server IP address (default port is `8080`) into the input field.
   * Tap the connect button. The server IP is automatically saved in `PlayerPrefs` for future sessions.
2. **Scan Reference Images**:
   * Point the camera at one of the tracked physical images (sample target images can be found in `Assets/ImageTrackingResources/TrackedImageJPG/`, such as `house.jpg`, `vase.jpg`, or `xrglasses.jpg`).
3. **Runtime Asset Loading**:
   * A loading indicator appears anchored to the tracked target image.
   * The app requests model metadata from the backend API, downloads the `.glb`/`.gltf` asset via its presigned URL, and renders it in real-time in the AR environment.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTORS -->
## Contributors

This repository represents an academic university project developed for coursework at the University of L'Aquila. As this project is closed and maintained for academic archival purposes, external contributions and pull requests are not accepted.

### Top contributors:

<a href="https://github.com/CarlinoCalogero/univaq-ais-mobile/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=CarlinoCalogero/univaq-ais-mobile" alt="contrib.rocks image" />
</a>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact

Calogero Carlino - [LinkedIn][linkedin-url] - [carlinocalogero.dev@gmail.com](mailto:carlinocalogero.dev@gmail.com)

Portfolio: [https://carlinocalogero.github.io](https://carlinocalogero.github.io)  
Project Link: [https://github.com/CarlinoCalogero/univaq-ais-mobile](https://github.com/CarlinoCalogero/univaq-ais-mobile)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [University of L'Aquila (UNIVAQ)](https://www.univaq.it/)
* [Unity Technologies](https://unity.com/)
* [Unity AR Foundation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest)
* [Google ARCore](https://developers.google.com/ar)
* [glTFast by atteneder](https://github.com/atteneder/glTFast)
* [Best-README-Template](https://github.com/othneildrew/Best-README-Template)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/CarlinoCalogero/univaq-ais-mobile.svg?style=for-the-badge
[contributors-url]: https://github.com/CarlinoCalogero/univaq-ais-mobile/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/CarlinoCalogero/univaq-ais-mobile.svg?style=for-the-badge
[forks-url]: https://github.com/CarlinoCalogero/univaq-ais-mobile/network/members
[stars-shield]: https://img.shields.io/github/stars/CarlinoCalogero/univaq-ais-mobile.svg?style=for-the-badge
[stars-url]: https://github.com/CarlinoCalogero/univaq-ais-mobile/stargazers
[issues-shield]: https://img.shields.io/github/issues/CarlinoCalogero/univaq-ais-mobile.svg?style=for-the-badge
[issues-url]: https://github.com/CarlinoCalogero/univaq-ais-mobile/issues
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/calogero-carlino-2a94a33b5/
[Unity]: https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white
[Unity-url]: https://unity.com/
[CSharp]: https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white
[CSharp-url]: https://learn.microsoft.com/en-us/dotnet/csharp/
[ARFoundation]: https://img.shields.io/badge/AR_Foundation-000000?style=for-the-badge&logo=unity&logoColor=white
[ARFoundation-url]: https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.1/manual/index.html
[ARCore]: https://img.shields.io/badge/Google_ARCore-4285F4?style=for-the-badge&logo=google&logoColor=white
[ARCore-url]: https://developers.google.com/ar
[glTFast]: https://img.shields.io/badge/glTFast-E63946?style=for-the-badge&logo=khronosgroup&logoColor=white
[glTFast-url]: https://github.com/atteneder/glTFast
