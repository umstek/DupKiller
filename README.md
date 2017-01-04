# DupKiller
Slow, but more reliable duplicate files cleaner. 

## Test Case (Real files):
	Size: ~13 GB
	Files: ~10k
	Folders: ~1k
	
	Settings: {File Type, File Size, Content Hash}, Recycle, Delete Empty Folders
	Time Taken: <10 min (scan); >1 min (recycle)
	Determining Factor: 1TB, 5400 RPM, 8MB, SATA 6.0Gb/s, HDD/Mobile
	
	Resultant Size: ~9.5 GB
	Resultant files: ~6k
	Resultant Folders: ~650
