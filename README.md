# DupKiller
Slow, but more reliable duplicate files cleaner. 

A perfect duplicate files finder would have to compare the content of each file with the 
content of everything else. This has a O(n^2) complexity, and since the files can be 
large, this is not possible and will take a long time to complete. If a dictionary i.e.: 
a hashmap can be created with the content as keys and paths as values, we can identify 
duplicate files quickly. But this is neither a viable option because all the files will 
have to be stored in memory and a dictionary will not work properly with that. 
Most of the current software use file size and extension to find the duplicate files but 
this can be inaccurate in various instances e.g.: uncompressed images that are the same 
size. 
So, the best option is to consider multiple factors, and allow user to select whether to 
use them. These factors should include a hash function. If the user suspects a hash 
collision, there should be a way to raw compare the files. Since we have filtered 
possible duplicates by various means, such incident can rarely occur. 

Group by extension (optional default yes), file name (optional default no), 
file size, shorter hash (MD5), longer hash (SHA512)
