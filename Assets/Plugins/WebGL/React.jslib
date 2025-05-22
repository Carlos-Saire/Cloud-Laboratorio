mergeInto(LibraryManager.library, {
  ReceiveUnityMessage: function (message) {
    try {
      window.dispatchReactUnityEvent("ReceiveUnityMessage", message);
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
});