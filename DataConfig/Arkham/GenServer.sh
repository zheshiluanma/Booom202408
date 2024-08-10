#!/bin/zsh

SRC_PACKAGE=veerland
echo "gen ${SRC_PACKAGE}"
sh ../__Server/ExcelGenServer.sh $(cd $(dirname $0);pwd) ${SRC_PACKAGE}