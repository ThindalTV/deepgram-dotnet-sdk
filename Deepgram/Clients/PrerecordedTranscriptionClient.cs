﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Deepgram.Interfaces;
using Deepgram.Models;

namespace Deepgram.Clients
{
    public class PrerecordedTranscriptionClient : BaseClient, IPrerecordedTranscriptionClient
    {
        public PrerecordedTranscriptionClient(Credentials credentials) : base(credentials) { }
        /// <inheritdoc />
        public async Task<PrerecordedTranscription> GetTranscriptionAsync(UrlSource source, PrerecordedTranscriptionOptions options)
        {
            var req = RequestMessageBuilder.CreateHttpRequestMessage(
               HttpMethod.Post,
               "listen",
               Credentials,
               source,
               options);

            return await ApiRequest.SendHttpRequestAsync<PrerecordedTranscription>(req);
        }

        /// <inheritdoc />
        public async Task<PrerecordedTranscription> GetTranscriptionAsync(StreamSource source, PrerecordedTranscriptionOptions options)
        {
            var req = RequestMessageBuilder.CreateStreamHttpRequestMessage(
             HttpMethod.Post,
             "listen",
             Credentials,
             source,
             options);

            return await ApiRequest.SendHttpRequestAsync<PrerecordedTranscription>(req);
        }

        /// <inheritdoc />
        public async Task<PrerecordedTranscriptionCallbackResult> GetTranscriptionAsync(UrlSource source, string callbackUrl, PrerecordedTranscriptionOptions options)
        {
            if (!String.IsNullOrEmpty(options.Callback) && !String.IsNullOrEmpty(callbackUrl))
            {
                throw new System.ArgumentException("CallbackUrl is already set in the options object. Please use one or the other.");
            }

            if (!String.IsNullOrEmpty(callbackUrl))
            {
                options.Callback = callbackUrl;
            }

            var req = RequestMessageBuilder.CreateHttpRequestMessage(
             HttpMethod.Post,
             "listen",
             Credentials,
             source,
             options);
            return await ApiRequest.SendHttpRequestAsync<PrerecordedTranscriptionCallbackResult>(req);
        }

        /// <inheritdoc />
        public async Task<PrerecordedTranscriptionCallbackResult> GetTranscriptionAsync(StreamSource source, string callbackUrl, PrerecordedTranscriptionOptions options)
        {
            if (!String.IsNullOrEmpty(options.Callback) && !String.IsNullOrEmpty(callbackUrl))
            {
                throw new System.ArgumentException("CallbackUrl is already set in the options object. Please use one or the other.");
            }

            if( !String.IsNullOrEmpty(callbackUrl)) {
                options.Callback = callbackUrl;
            }

            var req = RequestMessageBuilder.CreateStreamHttpRequestMessage(
             HttpMethod.Post,
             "listen",
             Credentials,
             source,
             options);
            return await ApiRequest.SendHttpRequestAsync<PrerecordedTranscriptionCallbackResult>(req);
        }
    }
}
