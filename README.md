# Find Duplicated Images


## Algorithm from [findimagedupes](http://www.jhnc.org/findimagedupes/)

**findimagedupes** compares a list of files for visual similarity.

* To calculate an image fingerprint:
  * Read image.
  * Resample to 160x160 to standardize size.
  * Grayscale by reducing saturation.
  * Blur a lot to get rid of noise.
  * Normalize to spread out intensity as much as possible.
  * Equalize to make image as contrasty as possible.
  * Resample again down to 16x16.
  * Reduce to 1bpp.
  * The fingerprint is this raw image data.

* To compare two images for similarity:
  * Take fingerprint pairs and xor them.
  * Compute the percentage of 1 bits in the result.
  * If percentage exceeds threshold, declare files to be similar.
  
  