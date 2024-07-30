const library = {

    // Class definition.

    $signalRSdk: {
	
		connection: null,
	
        initializeSignalR: function(url, gameEventStatusChangedCallbackPtr) {
			var hubUrl = UTF8ToString(url);
			var tmpConnection = new signalR.HubConnectionBuilder().withUrl(hubUrl);
			
			connection = tmpConnection.build();

			connection.on("EventStatusChanged", function (message) {
				signalRSdk.jsonCallback(message, gameEventStatusChangedCallbackPtr);
			});

			connection.start().catch(function (err) {
				console.error(err.toString());
			});
		},
		
		sendMessageToUser: function(userId, message) {
			connection.invoke("SendMessageToUser", userId, message).catch(function (err) {
				console.error(err.toString());
			});
		},
		
		jsonCallback: function (result, callbackPtr) {
            const entriesJson = JSON.stringify(result);
            const stringBufferSize = lengthBytesUTF8(entriesJson) + 1;
            const stringBufferPtr = _malloc(stringBufferSize);
            stringToUTF8(entriesJson, stringBufferPtr, stringBufferSize);
            dynCall('vi', callbackPtr, [stringBufferPtr]);
            _free(stringBufferPtr);
        },
    },

    // External C# calls.

	InitializeSignalR: function(url, gameEventStatusChangedCallbackPtr) {
		signalRSdk.initializeSignalR(url, gameEventStatusChangedCallbackPtr);
	},
	
	SendMessageToUser: function(userId, message) {
		signalRSdk.sendMessageToUser(userId, message);
	},
}

autoAddDeps(library, '$signalRSdk');
mergeInto(LibraryManager.library, library);