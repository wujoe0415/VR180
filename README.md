# VR180
## Discipition
This project is an assignment to CYCU VR180 Interaction Design Class.

## APK File
This link contains the final apk file.
It is for Android only, and user can download directly by Android cellphone. Alternativly, downloading with computer and transmitting to Android cellphone.  
[file.apk](https://drive.google.com/drive/folders/1Ht5i6OuEvXUnGdxYJgUOniMSvljXshPh)

## Code Discripition
+ Camera to point
  This is a default code with Google Cardboard. Attaching to camera object to detect users' behavior.
 
+ Debug Camera
  The logic of this code is the same as the above code.
  However, the above code cannot run on Unity self, so I write this code to help debugging.
  
 + <Object>Controller
  While camera casting a ray to **the object with collide**, it will send message to call the function inside this code, depending on the Enter / Exit / Click behaviors.
