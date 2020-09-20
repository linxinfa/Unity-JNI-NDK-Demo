LOCAL_PATH := $(call my-dir)
 
include $(CLEAR_VARS)
 
LOCAL_MODULE    := linxinfa_so
LOCAL_SRC_FILES := \
cs_call_c.c \
cs_call_cpp.cpp \
cpp_call_cs.h \
cpp_call_cs.cpp \
java_call_cpp.cpp \
cpp_call_java.cpp
 
include $(BUILD_SHARED_LIBRARY)