# ADOFAI Runner
Unity Editor extension for ADOFAI mod developers working alongside Thunderkit.

#### Make sure to read the guide to properly use this package!

***

## Features
* **Symbol Definer** - Help define build symbol for different compiled build. Use to quickly switch between build to compile for different mod managers.
	* Currently supported mod managers: BepInEx & UnityModManager.
* **Run** - Choose the corresponding mod added in the settings and click run -> 
	* Compile everything by executing ThunderKit's pipeline.
	* Move all the needed file to a mod folder named based off of the pipeline's manifest identity name.
	* Execute the game automatically.
* **FRun** - Quickly launch the executable based off of the chosen build.

## Guide on how to use Custom Otto Image

### **For static Otto:** 
* Input or browse for the path to the image (e.g., path1/path2/image.png) for the Otto state you'd like to change and then hit "Apply". 

### **For animated Otto:** 
* Input or browse for the path to the image (e.g., path1/path2/image.png) for the Otto state you'd like to change and then hit "Apply". 

* **Old/Alternative Method:**
To make Otto animate. Choose an animated file of your choice (e.g., .gif or .mp4) and turn the video into each seperate frame images. A website for this I recommend is [reaConverter](https://online.reaconverter.com/). Once you have all the frames of your desired animated source as each individual images. Name them all the same with their proper index, for example, name1.png, name2.png, etc... and put all the frames into a folder. Finally direct the ingame path into that folder and click "Apply". Currently, only .png, .jpg and .jpeg frames image type are supported. .jpg and .jpeg will not support transparency channel and so if they do have one, it will be turned to black pixels!!

* Tip: Please refrain from using long videos or folders with too many frames, since - unless your computer is a beast - it will just crash. A good limit would be roughly 50 frames or 1-2 looping GIF/Video.

### **Additional Info**
* Each state have a default state, that can be assigned, allowing you to reuse images for unassigned states. For example, if you set the default state for "NervousOn" to "On", the mod will use the image assigned to the "On" state. If no image is assigned to "On", the game will default to its original image.

### **Presets:** 
* You can create a preset(s) of the current profile or a fresh default one, type in the name and it will save all settings into a button.
* You can also modify the preset after selecting, make sure to click Update Preset!!!

### **Blink Distance:**

![Blink Distance](./Images/Blink.png)
* You can adjust how long you want Otto to stay in the blink state after hitting a tile. Here are some examples:

<img src="./Images/50.png" alt="Distance" width="300"/> <img src="./Images/100.png" alt="Distance" width="300"/>

## Otto States

On & Off:

![Otto Image](./Images/otto_on.png) ![Otto Image](./Images/otto_off.png)

Nervous On & Off (Instead of White, Red):

![Nervous On Image](./Images/otto_nervous_on.png) ![Nervous Off Image](./Images/otto_off.png)

Left On & Off (Nervous uses the same image):

![Left Image](./Images/otto_left.png) ![Left Image](./Images/otto_off_left.png)

Right On & Off (Nervous uses the same image):

![Right Image](./Images/otto_right.png) ![Right Image](./Images/otto_off_right.png)

Pet: ![Pet Image](./Images/otto_happy.png) Miss: ![Pet Image](./Images/otto_miss.png)