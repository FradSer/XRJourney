# /bin/bash

echo "Removing Oculus folder..."
rm -rf ./Assets/Oculus ./Assets/Oculus.meta
echo "Removing files named with oculus, OVR, AndroidManifest, vrapi, vrlib, vrplatlib..."
find . -name "oculus" -exec rm -rf {} \;
find . -name "OVR" -exec rm -rf {} \;
find . -name "AndroidManifest" -exec rm -rf {} \;
find . -name "vrapi" -exec rm -rf {} \;
find . -name "vrlib" -exec rm -rf {} \;
find . -name "vrplatlib" -exec rm -rf {} \;
