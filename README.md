# DisneyPhotoPassScraper
## Usage
This program scrapes the preview images that disney's photopass website provides using the same methods that your browser would use to view their image gallery.

### Your Account Id
You can obtain your account id by logging into the photopass website, viewing an image, then looking at your browser's cookies for the website and finding a cookie named 'did' whose value looks like xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.

### Purpose (Why is this a thing?)
If you google "Download disney photopass images", you'll find guides from people that tell you to painstakingly clear your browser cache, scroll through the entire image gallery, look through your browser's networking debug tab, and download the links listed there. Either that, or the guides will tell you to take a screenshot of the website and crop stuff out. Ick! 

I had more than 100 images to download this way and the site was slow, so I figured I should write a script that could automate this for me automatically. Once again, no black magic here - it does everything your browser does.

### Quality
The downloaded images are, once again, preview images, so they will not be as great as the images you can purchase from the site. They're jpegs usually somewhere from 300KB-500KB in size at resolutions near 1280x853 and have obvious and ugly (likely nearest-neighbor) downscaling.

## Licensing
Code is GPLv3 licensed.
