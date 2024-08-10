#!/bin/zsh

WORKSPACE=../__LuBan/Luban.ClientServer
GEN_CLIENT=${WORKSPACE}/Luban.ClientServer.dll
EXCEL_PATH=$1
#SPACE_SERVER_PATH=../../../quark/quark-game
GEN_CODE_DEST_PATH=../../../quark/quark-game
GEN_JSON_SPACE_PATH=../../../lalande/lalande-space-server
GEN_JSON_LOBBY_PATH=../../../lalande/lalande-lobby-server
SRC_DIR=$2

rm -fr ${EXCEL_PATH}/src
rm -fr ${EXCEL_PATH}/output_json

dotnet ${GEN_CLIENT} -j cfg --\
 -d ${EXCEL_PATH}/Defines/__server__.xml \
 --input_data_dir ${EXCEL_PATH} \
 --output_data_dir ${EXCEL_PATH}/output_json/${SRC_DIR} \
 --output_code_dir ${EXCEL_PATH}/src/main/java/tv/veer/lalande/conf/${SRC_DIR} \
 --gen_types code_java_json,data_json \
 -s server

rm -fr ${GEN_CODE_DEST_PATH}/src/main/java/tv/veer/lalande/conf/${SRC_DIR}/*
rm -fr ${GEN_JSON_SPACE_PATH}/src/main/resources/conf/${SRC_DIR}/*
rm -fr ${GEN_JSON_LOBBY_PATH}/src/main/resources/conf/${SRC_DIR}/*

mv ${EXCEL_PATH}/src/main/java/tv/veer/lalande/conf/${SRC_DIR}  ${GEN_CODE_DEST_PATH}/src/main/java/tv/veer/lalande/conf/
cp -r ${EXCEL_PATH}/output_json/${SRC_DIR}  ${GEN_JSON_LOBBY_PATH}/src/main/resources/conf/
mv ${EXCEL_PATH}/output_json/${SRC_DIR}  ${GEN_JSON_SPACE_PATH}/src/main/resources/conf/

rm -fr ${EXCEL_PATH}/src
rm -fr ${EXCEL_PATH}/output_json
rm .cache.meta