#!/bin/bash
# https://hub.docker.com/r/hyness/spring-cloud-config-server/
# http://localhost:8888/config/master
IMAGE="hyness/spring-cloud-config-server"


REMOTE_CONFIG=""
LOCAL_CONFIG=""
PORT_CONFIG=""

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

if [ -z "$PORT_CONFIG" ]; then
        echo 'Missing -p (port) option' >&2
        exit 1
fi

# if image not installed locally, fetch
if [[ "$(docker images -q $IMAGE 2> /dev/null)" == "" ]]; then
	echo 'Image not present, pulling image....'
    docker pull $IMAGE
	echo 'Image pulled successfully.'
fi

if [ -z "$REMOTE_CONFIG" ]; then
   docker run -it -p "$PORT_CONFIG":"$PORT_CONFIG" -v "$LOCAL_CONFIG":/config "$IMAGE"
else 
   docker run -it -p "$PORT_CONFIG":"$PORT_CONFIG" -e SPRING_CLOUD_CONFIG_SERVER_GIT_URI=$REMOTE_CONFIG "$IMAGE"
fi
 
echo "Test by going to "http://localhost:${PORT_CONFIG}/{reponame}/{branchname}"

