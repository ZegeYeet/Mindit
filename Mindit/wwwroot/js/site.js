// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



async function ClickVoteButton(postId, voteButton, voteCountText)
{
    ForumPostChangeVote(postId, voteButton.value, voteCountText)
    
}

function ToggleVoteButtonIcon(element)
{

    if (element.value == "upvoteEmpty") {
        element.style.backgroundImage = "url('Images/upvoteIconFull.png')";
        element.value = "upvoteFull";
    }
    else if (element.value == "upvoteFull") {
        element.style.backgroundImage = "url('Images/upvoteIconEmpty.png')";
        element.value = "upvoteEmpty";
    }
    else if (element.value == "downvoteEmpty") {
        element.style.backgroundImage = "url('Images/downvoteIconFull.png')";
        element.value = "downvoteFull";
    }
    else if (element.value == "downvoteFull") {
        element.style.backgroundImage = "url('Images/downvoteIconEmpty.png')";
        element.value = "downvoteEmpty";
    }
}

function ForumPostRefreshVotes(postId, voteCountText)
{


    $.ajax({
        url: '/ForumPosts/GetVoteCount/',
        type: 'GET',
        data: {'postID': postId},
        dataType: 'json',
        success: function (data) {
            voteCountText.innerHTML = data.voteCount;
        },
        error: function (error) {
            console.log(error);
        }
    });
}

async function ForumPostChangeVote(postId, newVoteValue, voteCountText) {


    $.ajax({
        url: '/ForumPosts/ChangeVoteCount/',
        type: 'POST',
        data: { 'postID': postId, 'voteValue': newVoteValue },
        dataType: 'json',
        success: function (data) {
            if (data.voteStyle != null) {
                ForumPostRefreshVotes(postId, voteCountText);
                SetIconsAfterVote(postId, data.voteStyle);
                ToggleVoteButtonIcon(voteButton);
            }
            return true;
        },
        error: function (error) {
            console.log("error: " + error);
        }
    });

    return false;
}

function SetIconsAfterVote(postId, voteValue) {

    var upvoteButton = document.getElementById("upvoteButton " + postId);
    var downvoteButton = document.getElementById("downvoteButton " + postId);

    if (voteValue == "upvoteFull") {
        upvoteButton.style.backgroundImage = "url('../../Images/upvoteIconFull.png')";
        upvoteButton.value = "upvoteFull";
        downvoteButton.style.backgroundImage = "url('../../Images/downvoteIconEmpty.png')";
        downvoteButton.value = "downvoteEmpty";
    }
    else if (voteValue == "downvoteFull") {
        upvoteButton.style.backgroundImage = "url('../../Images/upvoteIconEmpty.png')";
        upvoteButton.value = "upvoteEmpty";
        downvoteButton.style.backgroundImage = "url('../../Images/downvoteIconFull.png')";
        downvoteButton.value = "downvoteFull";
    }
    else { //neutral or no vote cases
        upvoteButton.style.backgroundImage = "url('../../Images/upvoteIconEmpty.png')";
        upvoteButton.value = "upvoteEmpty";
        downvoteButton.style.backgroundImage = "url('../../Images/downvoteIconEmpty.png')";
        downvoteButton.value = "downvoteEmpty";
    }
}

function FilterCategory(mindyName) {

    window.location.href = "/ForumPosts/NavMindySelection?navClass=" + mindyName;

}



