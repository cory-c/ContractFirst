#!/bin/bash

TARGET_DIR='../Dockerfiles'
CONFIG_SERVICE_DIR="$TARGET_DIR/config-server"

REMOTE_CONFIG=""
LOCAL_CONFIG=""
PORT_CONFIG="8080"

# parsing cli flags
while getopts 'l:r:p:' OPTION; do
  case "$OPTION" in
    l) 
      LOCAL_CONFIG=${OPTARG} 
      ;;
    r)
      REMOTE_CONFIG=${OPTARG}
      ;;
    p)
      PORT_CONFIG=${OPTARG}
      ;;
    ?)
       exit 1
       ;; 
  esac
done
shift "$(($OPTIND -1))"

# Ensuring either local or remote is provided
if [ -z "$REMOTE_CONFIG" ] && [ -z "$LOCAL_CONFIG" ]; then
        echo 'Missing -l (local file) or -r (remote repo) options' >&2
        exit 1
fi

# cloning / updating docker files
git -C "$TARGET_DIR" pull || git clone https://github.com/SteeltoeOSS/Dockerfiles.git "$TARGET_DIR"

# starting config server docker instance
if [ -z "$REMOTE_CONFIG" ]; then
   docker run --publish "$PORT_CONFIG":"$PORT_CONFIG" --volume "$LOCAL_CONFIG":/config "$TARGET_DIR" \
       --spring.profiles.active=native \
       --spring.cloud.config.server.native.searchLocations=file:///config 
else 
   docker run --publish 8888:8888 steeltoeoss/config-server --spring.cloud.config.server.git.uri="$REMOTE_CONFIG"
fi
 








